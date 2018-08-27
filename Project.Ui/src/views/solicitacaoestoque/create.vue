<template>

	<main class="main">

		<ol class="breadcrumb">

			<li class="breadcrumb-item"><a href="/home">Home</a></li>
			<li class="breadcrumb-item">Solicitação de Estoque</li>
			<li class="breadcrumb-item active">Criar</li>

			<li class="breadcrumb-menu d-md-down-none">
				<div class="btn-group">
					<a class="btn" @click="onBack()"><i class="fa fa-reply"></i> Voltar</a>
				</div>
			</li>

		</ol>

		<div class="container-fluid">
			<div class="animated fadeIn">
				<div class="row">
					<div class="col-sm-12">
						<div class="card">
							<div class="card-header">
								<strong>Criar</strong>
								Solicitação de Estoque
							</div>
							<div class="card-body">
								<form-create v-if="dialogCreate" :id="solicitacaoEstoqueId" @on-saved="onSaved" @on-back="onBack()" />
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>

    </main>

</template>
<script>

    import formCreate from './form-create'

    export default {
        name: 'solicitacaoestoque-create',
        components: { formCreate },
        data: () => ({
            dialogCreate: false,
        }),
        methods: {
            onSaved: function (data) {
                this.$router.push({ path: '/solicitacaoestoque/edit/' + data.data.solicitacaoEstoqueId });
            },
            onBack: function () {
                this.$router.go(-1);
            }
        },
		mounted() {
			this.dialogCreate = true;
        }
    };
</script>

