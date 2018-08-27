<template>

    <form ref="solicitacaoestoque-form-create" v-on:submit.prevent="executeCreate(model)" novalidate>

        <div class="row">

            <div class="form-group col-md-12">
                <label for="dataPrevista">Data Prevista</label>
                <input type="date" v-datepicker class="form-control" name="dataPrevista" v-model="model.dataPrevista" required />
            </div>
            <div class="form-group col-md-12">
                <label for="descricao">Descrição</label>
                <textarea type="text" class="form-control" name="descricao" autocomplete="off" placeholder="Descrição" v-model="model.descricao" required />
            </div>


        </div>

        <button type="button" class="btn btn-default" @click="onBack()">
            <span>Voltar</span>
        </button>
        <button type="button" class="btn btn-success float-right" @click="executeCreate(model)">
            <span>Salvar</span>
        </button>

    </form>


</template>
<script>
    
	import base from '@/common/base.js'
    import { Api } from '@/common/api'

    export default {
        name: "solicitacaoestoque-form-create",
        mixins: [base],
        data: () => ({

            model: {},

            form: "solicitacaoestoque-form-create",
            
            resources: {
                create: 'solicitacaoestoque',
            },

        }),
		
        methods: {

            executeCreate: function (model) {

                if (this.formValidate() == false)
                    return;

                new Api(this.resources.create).post(model).then(data => {
                    this.$emit('on-saved', data)
                    this.defaultSuccessResult('Registro inserido com sucesso');
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
    };
</script>

