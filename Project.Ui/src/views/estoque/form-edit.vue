<template>

    <form ref="estoque-form-edit" v-on:submit.prevent="executeEdit(model)" novalidate>

        <div class="row">


            <div class="form-group col-md-8">
                <label for="nome">Nome</label>
                <input type="text" class="form-control" name="nome" autocomplete="off" placeholder="Nome" v-model="model.nome" required />
            </div>

            <div class="form-group col-md-4">
                <label for="referencia">Código</label>
                <input type="number" class="form-control" name="referencia" autocomplete="off" placeholder="Código" v-model="model.referencia" />
            </div>

            <div class="form-group col-md-4">
                <label for="localizacao">Localização</label>
                <input type="text" class="form-control" name="localizacao" autocomplete="off" placeholder="Localizacao" v-model="model.localizacao" />
            </div>

            <div class="form-group col-md-4">
                <label for="modelo">Modelo</label>
                <input type="text" class="form-control" name="modelo" autocomplete="off" placeholder="Modelo" v-model="model.modelo" />
            </div>

            <div class="form-group col-md-4">
                <label for="fabricante">Fabricante</label>
                <input type="text" class="form-control" name="fabricante" autocomplete="off" placeholder="Fabricante" v-model="model.fabricante" />
            </div>

            <div class="form-group col-md-6">
                <label for="unidadeMedidaId">Unidade de Medida</label>
                <select v-select="{ dataitem: 'UnidadeMedida', default: 'Selecione' }" v-model="model.unidadeMedidaId" class="form-control" name="unidadeMedidaId" required></select>
            </div>

            <div class="form-group col-md-6">
                <label for="categoriaEstoqueId">Categoria de Estoque</label>
                <select v-select="{ dataitem: 'CategoriaEstoque', default: 'Selecione' }" v-model="model.categoriaEstoqueId" class="form-control" name="categoriaEstoqueId" required></select>
            </div>

            <div class="form-group col-md-12">
                <label for="observacao">Observação</label>
                <textarea type="text" class="form-control" name="observacao" autocomplete="off" placeholder="Observacao" v-model="model.observacao" />
            </div>

            <div class="form-group col-md-12">
                <label for="descricao">Descrição</label>
                <textarea type="text" class="form-control" name="descricao" autocomplete="off" placeholder="Descricao" v-model="model.descricao" />
            </div>

            <!--<div class="form-group col-md-12">
        <label for="referencia">Referencia</label>
        <input type="text" class="form-control" name="referencia" autocomplete="off" placeholder="Referencia" v-model="model.referencia" />
    </div>-->



            <div class="form-group col-md-4">
                <label for="quantidadeMinima">Quantidade Mínima</label>
                <input type="number" class="form-control" name="quantidadeMinima" autocomplete="off" placeholder="QuantidadeMinima" v-model="model.quantidadeMinima" required />
            </div>
            <!--<div class="form-group col-md-12">
        <label for="quantidade">Quantidade</label>
        <input type="text" class="form-control" name="quantidade" autocomplete="off" placeholder="Quantidade" v-model="model.quantidade" required />
    </div>-->
            <div class="form-group col-md-4">
                <label for="valorVenda">Valor da Venda</label>
                <input type="text" class="form-control" name="valorVenda" autocomplete="off" placeholder="ValorVenda" v-model="model.valorVenda" />
            </div>
            <div class="form-group col-md-4">
                <label for="valorCompra">Valor da Compra</label>
                <input type="text" class="form-control" name="valorCompra" autocomplete="off" placeholder="ValorCompra" v-model="model.valorCompra" />
            </div>
            <div class="form-group col-md-12">
                <div class="clearfix">&nbsp;</div>
                <label class="custom-control custom-checkbox">
                    <input type="checkbox" name="ativo" class="custom-control-input" v-model="model.ativo">
                    <span class="custom-control-indicator"></span>
                    <span class="custom-control-description"> Ativo?</span>
                </label>
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
        name: "estoque-form-edit",
        mixins: [base],
        props: { id: Number },
        data: () => ({

            model: {},

            form: "estoque-form-edit",

            resources: {
                edit: 'estoque',
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
            new Api(this.resources.edit).get({ estoqueId: this.id }).then(data => {
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