<template>
    <main class="main">

        <ol class="breadcrumb">

            <li class="breadcrumb-item"><a href="/home">Home</a></li>
            <li class="breadcrumb-item active">Solicitação de Estoque</li>

            <li class="breadcrumb-menu d-md-down-none">
                <div class="btn-group">
                    <a class="btn" @click="exportResults()"><i class="fa fa-file"></i> Exportar</a>
                    <a class="btn" @click="openFilter()"><i class="fa fa-search"></i> Filtros</a>
                    <a class="btn" @click="openCreate()"><i class="fa fa-plus"></i> Novo</a>
                </div>
            </li>

        </ol>
        <div class="container-fluid">
            <div class="row animated fadeIn" v-if="dialogFilter">
                <div class="col-sm-12">
                    <form v-on:submit.prevent="executeFilter(filter)">
                        <div class="card">
                            <div class="card-header">
                                <strong>Filtros</strong>
                            </div>
                            <div class="card-body">
                                <div class="row">
                                    <div class="form-group col-md-12">
                                        <label for="descricao">Descricao</label>
                                        <textarea type="text" class="form-control" name="descricao" autocomplete="off" placeholder="Descricao" v-model="filter.descricao" />
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label for="solicitanteId">SolicitanteId</label>
                                        <input type="text" class="form-control" name="solicitanteId" autocomplete="off" placeholder="SolicitanteId" v-model="filter.solicitanteId" />
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label for="dataSolicitacao">DataSolicitacao</label>
                                        <input type="text" v-datepicker class="form-control" name="dataSolicitacao" v-model="filter.dataSolicitacao" />
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label for="dataPrevista">DataPrevista</label>
                                        <input type="text" v-datepicker class="form-control" name="dataPrevista" v-model="filter.dataPrevista" />
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label for="statusSolicitacaoEstoqueMovimentacaoId">StatusSolicitacaoEstoqueMovimentacaoId</label>
                                        <input type="text" class="form-control" name="statusSolicitacaoEstoqueMovimentacaoId" autocomplete="off" placeholder="StatusSolicitacaoEstoqueMovimentacaoId" v-model="filter.statusSolicitacaoEstoqueMovimentacaoId" />
                                    </div>

                                </div>
                            </div>
                            <div class="card-footer">
                                <div class="btn-group pull-right">
                                    <button type="button" class="btn btn-default" @click="openFilter()">Fechar</button>
                                    <button type="button" class="btn btn-success" @click="executeFilter(filter)">Buscar</button>
                                </div>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
            <div class="row animated fadeIn">
                <div class="col-xs-12 col-sm-7 col-md-7 col-lg-8">
                    <h6 class="page-title txt-color-blueDark">
                        <i class="fa-fw fa fa-home"></i>
                        
                        <span>Solicitação de movimentação de estoque</span>
                    </h6>
                </div>
                <div class="col-sm-12">
                    <div class="card">
                        <div class="card-header">
                            <strong>Resultado</strong>
                        </div>
                        <div class="card-body">
                            <table class="table table-hover table-striped">
                                <thead>
                                    <tr>
                                        <th>#</th>
                                        <th>Descricao<i @click="executeOrderBy('Descricao')" class="fa fa-sort th-sort"></i></th>
                                        <th>#</th>
                                        <th>DataSolicitacao<i @click="executeOrderBy('DataSolicitacao')" class="fa fa-sort th-sort"></i></th>
                                        <th>DataPrevista<i @click="executeOrderBy('DataPrevista')" class="fa fa-sort th-sort"></i></th>
                                        <th>#</th>

                                        <th class="text-center" width="150"><i class="fa fa-cog"></i></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr v-for="item in result.items" v-bind:key="item.solicitacaoEstoqueId" class="animated fadeIn">
                                        <td>{{ item.solicitacaoEstoqueId }}</td>
                                        <td>{{ item.descricao }}</td>
                                        <td>{{ item.solicitanteId }}</td>
                                        <td>{{ item.dataSolicitacao }}</td>
                                        <td>{{ item.dataPrevista }}</td>
                                        <td>{{ item.statusSolicitacaoEstoqueMovimentacaoId }}</td>

                                        <td class="text-center">
                                            <div class="btn-group">
                                                <button type="button" class="btn btn-sm btn-primary" v-b-tooltip title="Editar" @click="openEdit(item)">
                                                    <i class="fa fa-pencil"></i>
                                                </button>
                                                <button type="button" class="btn btn-sm btn-danger" v-b-tooltip title="Remover" @click="openRemove({ solicitacaoEstoqueId: item.solicitacaoEstoqueId })">
                                                    <i class="fa fa-trash-o"></i>
                                                </button>
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <div class="card-block no-padding">
                                <pagination :total="result.total" :page-size="filter.pageSize" :callback="executePageChanged"></pagination>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <b-modal centered v-model="dialogCreate" :hide-footer="true" title="Criar">
            <form-create v-if="dialogCreate" @on-saved="onSaved()" @on-back="hideAll()" />
        </b-modal>

        <b-modal centered v-model="dialogEdit" :hide-footer="true" title="Editar">
            <form-edit v-if="dialogEdit" :id="solicitacaoEstoqueId" @on-saved="onSaved()" @on-back="hideAll()" />
        </b-modal>

        <b-modal centered v-model="dialogRemove" title="Confirmação">
            <p>Tem certeza que deseja remover este item?</p>
            <div slot="modal-footer">
                <button class="btn btn-sm btn-danger" @click="executeRemove()">
                    Remover
                </button>
            </div>
        </b-modal>

    </main>

</template>
<script>

    import base from '@/common/base.js'
    import { Api } from '@/common/api'

    import formCreate from './form-create'
    import formEdit from './form-edit'

    export default {
        name: 'solicitacaoestoque',
        mixins: [base],
        components: { formCreate, formEdit },
        data() {
            return {

                resources: {
                    filter: 'solicitacaoestoque',
                    remove: 'solicitacaoestoque'
                },

                dialogRemove: false,
                dialogCreate: false,
                dialogEdit: false,
                dialogFilter: false,

                model: {},
                filter: {
                    pageSize: 50,
                    pageIndex: 1,
                    isPagination: true,
                },

                result: {
                    total: 0,
                    items: []
                }
            }
        },
        methods: {
            openEdit: function (model) {
                this.solicitacaoEstoqueId = model.solicitacaoEstoqueId;
                this.dialogEdit = true;
            },
            openCreate: function () {
                this.dialogCreate = true;
            },
            onSaved: function () {
                this.hideAll();
                this.executeLoad();
            },
            hideAll: function () {
                this.dialogCreate = false;
                this.dialogEdit = false;
                this.dialogRemove = false;
            },

            openFilter: function () {
                this.dialogFilter = !this.dialogFilter;
            },
            openRemove: function (model) {
                this.dialogRemove = true;
                this.model = model;
            },
            executeRemove: function (model) {
                if (model) this.model = model;
                new Api(this.resources.remove).delete(this.model).then(() => {
                    this.defaultSuccessResult("Item removido com sucesso");
                    this.hideAll();
                    this.executeLoad();
                }, err => {
                    this.defaultErrorResult(err);
                })
            },

            executeFilter: function (filter) {
                if (filter) this.filter = filter;
                this.executeLoad();
            },
            executePageChanged: function (index) {
                this.filter = this.defaultPageChanged(this.filter, index);
                this.executeLoad();
            },
            executeOrderBy: function (field) {
                this.filter = this.defaultOrderBy(this.filter, field);
                this.executeLoad();
            },
            executeLoad: function () {
                this.showLoading();
                new Api(this.resources.filter).get(this.filter).then(data => {
                    if (data.summary) this.result.total = data.summary.total;
                    this.result.items = data.dataList;
                    this.hideLoading();
                }, (err) => {
                    this.failLoading();
                    if (err && err.data && err.data.errors) {
                        this.$eventHub.$emit('show-notification', {
                            type: 'error',
                            title: 'Atenção',
                            text: err.data.errors[0]
                        })
                    }
                });
            },

        },

        mounted() {
            this.executeFilter();
        }

    };
</script>