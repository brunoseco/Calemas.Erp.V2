<template>

	<main class="main">

		<ol class="breadcrumb">

			<li class="breadcrumb-item"><a href="/home">Home</a></li>
			<li class="breadcrumb-item">Motivo de Movimentação de Estoque</li>
			<li class="breadcrumb-item active">Editar</li>

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
								<strong>Editar</strong>
								Motivo de Movimentação de Estoque
							</div>
							<div class="card-body">
								<form-edit v-if="dialogEdit" :id="motivoEstoqueMovimentacaoId" @on-saved="onSaved" @on-back="onBack()" />
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>

    </main>

</template>
<script>

    import formEdit from './form-edit'

    export default {
        name: 'motivoestoquemovimentacao-edit',
        components: { formEdit },
        data: () => ({
            dialogEdit: false,
			motivoEstoqueMovimentacaoId: 0
        }),
        methods: {
            onSaved: function (data) {
				if (data) this.$router.push({ path: '/motivoestoquemovimentacao' });
            },
            onBack: function () {
                this.$router.go(-1);
            }
        },
		mounted() {
			this.motivoEstoqueMovimentacaoId = +this.$route.params.id;
			this.dialogEdit = true;
        }
    };
</script>

