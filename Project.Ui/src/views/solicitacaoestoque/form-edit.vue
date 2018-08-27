<template>

    <form ref="solicitacaoestoque-form-edit" v-on:submit.prevent="executeEdit(model)" novalidate>

        <div class="row">


            <div class="form-group col-md-12">
                <label for="descricao">Descricao</label>
                <textarea type="text" class="form-control" name="descricao" autocomplete="off" placeholder="Descricao" v-model="model.descricao" required />
            </div>
            <!--<div class="form-group col-md-12">
                <label for="solicitanteId">SolicitanteId</label>
                <input type="text" class="form-control" name="solicitanteId" autocomplete="off" placeholder="SolicitanteId" v-model="model.solicitanteId" required />
            </div>
            <div class="form-group col-md-12">
                <label for="dataSolicitacao">DataSolicitacao</label>
                <input type="text" v-datepicker class="form-control" name="dataSolicitacao" v-model="model.dataSolicitacao" required />
            </div>-->
            <div class="form-group col-md-6">
                <label for="dataPrevista">DataPrevista</label>
                <input type="text" v-datepicker class="form-control" name="dataPrevista" v-model="model.dataPrevista" required />
            </div>
            <div class="form-group col-md-6">
                <label for="statusSolicitacaoEstoqueMovimentacaoId">SolicitacaoEstoqueMovimentacaoId</label>
                <input type="text" class="form-control" name="statusSolicitacaoEstoqueMovimentacaoId" autocomplete="off" placeholder="StatusSolicitacaoEstoqueMovimentacaoId" v-model="model.statusSolicitacaoEstoqueMovimentacaoId" required />
            </div>


        </div>

        <button type="button" class="btn btn-default" @click="onBack()">
            <span>Voltar</span>
        </button>
        <button type="button" class="btn btn-success float-right" @click="executeEdit(model)">
            <span>Salvar</span>
        </button>

    </form>


</template>
<script>

    import base from '@/common/base.js'
    import { Api } from '@/common/api'

    export default {
        name: "solicitacaoestoque-form-edit",
        mixins: [base],
        props: { id: Number },
        data: () => ({

            model: {},

            form: "solicitacaoestoque-form-edit",

            resources: {
                edit: 'solicitacaoestoque',
            },

        }),

        methods: {

            executeEdit: function (model) {

                if (this.formValidate() == false) return;

                new Api(this.resources.edit).put(model).then(data => {
                    this.defaultSuccessResult("Edição realizada com sucesso");
                    this.$emit('on-saved', data)
                }, err => {
                    this.defaultErrorResult(err);
                })
            },

            formValidate: function () {
                var $form = this.$refs[this.form];
                $form.classList.add("was-validated");
                return $form.checkValidity();
            },

            onBack: function () {
                this.$emit('on-back')
            }
        },

        mounted() {
            new Api(this.resources.edit).get({ solicitacaoEstoqueId: this.id }).then(data => {
                if (data.data) this.model = data.data;
                else if (!data.dataList) this.model = {};
                else if (data.dataList.length == 1) this.model = data.dataList[0];
                else this.model = {};
            }, err => {
                this.defaultErrorResult(err);
            })
        }
    };
</script>