<template>

    <form ref="estoquemovimentacaocolaborador-form-edit" v-on:submit.prevent="executeEdit(model)" novalidate>

        <div class="row">

            
					<div class="form-group col-md-12">
                        <label for="colaboradorId">ColaboradorId</label>
                        <input type="text" class="form-control" name="colaboradorId" autocomplete="off" placeholder="ColaboradorId" v-model="model.colaboradorId" required />
                    </div>
                    <div class="form-group col-md-12">
                        <label for="estoqueMovimentacaoId">EstoqueMovimentacao</label>
                        <select v-select="{ dataitem: 'EstoqueMovimentacao', default: 'Selecione' }" v-model="model.estoqueMovimentacaoId" class="form-control" name="estoqueMovimentacaoId" required></select>
                    </div>
					<div class="form-group col-md-12">
                        <div class="clearfix">&nbsp;</div>
                        <label class="custom-control custom-checkbox">
                            <input type="checkbox" name="entrada" class="custom-control-input" v-model="model.entrada">
                            <span class="custom-control-indicator"></span>
                            <span class="custom-control-description"> Entrada?</span>
                        </label>
                    </div>
					<div class="form-group col-md-12">
                        <label for="descricao">Descricao</label>
                        <input type="text" class="form-control" name="descricao" autocomplete="off" placeholder="Descricao" v-model="model.descricao"  />
                    </div>
					<div class="form-group col-md-12">
                        <label for="quantidade">Quantidade</label>
                        <input type="text" class="form-control" name="quantidade" autocomplete="off" placeholder="Quantidade" v-model="model.quantidade" required />
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
        name: "estoquemovimentacaocolaborador-form-edit",
        mixins: [base],
        props: { id: Number },
        data: () => ({

            model: {},

            form: "estoquemovimentacaocolaborador-form-edit",
            
            resources: {
                edit: 'estoquemovimentacaocolaborador',
            },

        }),
		
        methods: {

            executeEdit: function (model) {

                if (this.formValidate() == false)return;

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
            new Api(this.resources.edit).get({ estoqueMovimentacaoColaboradorId: this.id }).then(data => {
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