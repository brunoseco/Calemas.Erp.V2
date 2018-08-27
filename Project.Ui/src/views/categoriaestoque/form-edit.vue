<template>

    <form ref="categoriaestoque-form-edit" v-on:submit.prevent="executeEdit(model)" novalidate>

        <div class="row">

            
					<div class="form-group col-md-12">
                        <label for="nome">Nome</label>
                        <input type="text" class="form-control" name="nome" autocomplete="off" placeholder="Nome" v-model="model.nome" required />
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
        name: "categoriaestoque-form-edit",
        mixins: [base],
        props: { id: Number },
        data: () => ({

            model: {},

            form: "categoriaestoque-form-edit",
            
            resources: {
                edit: 'categoriaestoque',
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
            new Api(this.resources.edit).get({ categoriaEstoqueId: this.id }).then(data => {
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