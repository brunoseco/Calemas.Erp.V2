<template>
    <main class="main">

		<ol class="breadcrumb">

			<li class="breadcrumb-item"><a href="/home">Home</a></li>
			<li class="breadcrumb-item active">Movimentação de Estoque</li>

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
                        <label for="estoqueId">Estoque</label>
                        <select v-select="{ dataitem: 'Estoque', default: 'Selecione' }" v-model="filter.estoqueId" class="form-control" name="estoqueId" ></select>
                    </div>

				<div class="form-group col-md-12">
                    <label>Entrada</label>
                    <div class="form-group">
                        <label class="custom-control custom-radio">
                            <input type="radio" name="entrada" v-model="filter.entrada" value="undefined" class="custom-control-input">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description">Todos</span>
                        </label>
                        <label class="custom-control custom-radio">
                            <input type="radio" name="entrada" v-model="filter.entrada" value="true" class="custom-control-input">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description">Sim</span>
                        </label>
                        <label class="custom-control custom-radio">
                            <input type="radio" name="entrada" v-model="filter.entrada" value="false" class="custom-control-input">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description">Não</span>
                        </label>
                    </div>
                </div>
					<div class="form-group col-md-12">
                        <label for="descricao">Descricao</label>
                        <input type="text" class="form-control" name="descricao" autocomplete="off" placeholder="Descricao" v-model="filter.descricao"  />
                    </div>
					<div class="form-group col-md-12">
                        <label for="quantidade">Quantidade</label>
                        <input type="text" class="form-control" name="quantidade" autocomplete="off" placeholder="Quantidade" v-model="filter.quantidade"  />
                    </div>
                    <div class="form-group col-md-12">
                        <label for="motivoEstoqueMovimentacaoId">MotivoEstoqueMovimentacao</label>
                        <select v-select="{ dataitem: 'MotivoEstoqueMovimentacao', default: 'Selecione' }" v-model="filter.motivoEstoqueMovimentacaoId" class="form-control" name="motivoEstoqueMovimentacaoId" ></select>
                    </div>
					<div class="form-group col-md-12">
                        <label for="responsavelId">ResponsavelId</label>
                        <input type="text" class="form-control" name="responsavelId" autocomplete="off" placeholder="ResponsavelId" v-model="filter.responsavelId"  />
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
                        <span>Manutenção de Movimentação de estoque</span>
                    </h6>
                </div>
                <div class="col-sm-12">
                    <div class="card">
                        <div class="card-header">
                            <strong>Resultado</strong>
                            Movimentação de Estoque
                        </div>
                        <div class="card-body">
                            <table class="table table-hover table-striped">
                                <thead>
                                    <tr>
                                        <th>#</th>
                                        <th>Entrada<i @click="executeOrderBy('Entrada')" class="fa fa-sort th-sort"></i></th>
                                        <th>Descricao<i @click="executeOrderBy('Descricao')" class="fa fa-sort th-sort"></i></th>
                                        <th>Quantidade<i @click="executeOrderBy('Quantidade')" class="fa fa-sort th-sort"></i></th>
                                        <th>#</th>

                                        <th class="text-center" width="150"><i class="fa fa-cog"></i></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr v-for="item in result.items" v-bind:key="item.estoqueMovimentacaoId" class="animated fadeIn">
                                        <td>{{ item.estoqueMovimentacaoId }}</td>
                                        <td><span class="badge badge-pill" v-bind:class="{ 'badge-success': item.entrada, 'badge-danger': !item.entrada }">{{item.entrada ? 'Sim' : 'Não'}}</span></td>
                                        <td>{{ item.descricao }}</td>
                                        <td>{{ item.quantidade }}</td>
                                        <td>{{ item.responsavelId }}</td>

                                        <td class="text-center">
                                            <div class="btn-group">
                                                <button type="button" class="btn btn-sm btn-primary" v-b-tooltip title="Editar" @click="openEdit(item)">
                                                    <i class="fa fa-pencil"></i>
                                                </button>
                                                <button type="button" class="btn btn-sm btn-danger" v-b-tooltip title="Remover" @click="openRemove({ estoqueMovimentacaoId: item.estoqueMovimentacaoId })">
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
            <form-edit v-if="dialogEdit" :id="estoqueMovimentacaoId" @on-saved="onSaved()" @on-back="hideAll()" />
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
        name: 'estoquemovimentacao',
        mixins: [base],
        components: { formCreate, formEdit },
        data() {
            return {

                resources: {
                    filter: 'estoquemovimentacao',
                    remove: 'estoquemovimentacao'
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
                this.estoqueMovimentacaoId = model.estoqueMovimentacaoId;
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