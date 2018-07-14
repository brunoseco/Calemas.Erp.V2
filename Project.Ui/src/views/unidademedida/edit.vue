<template>

	<main class="main">

		<ol class="breadcrumb">

			<li class="breadcrumb-item"><a href="/home">Home</a></li>
			<li class="breadcrumb-item">Unidade de Medida</li>
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
								Unidade de Medida
							</div>
							<div class="card-body">
								<form-edit v-if="dialogEdit" :id="unidadeMedidaId" @on-saved="onSaved" @on-back="onBack()" />
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
        name: 'unidademedida-edit',
        components: { formEdit },
        data: () => ({
            dialogEdit: false,
			unidadeMedidaId: 0
        }),
        methods: {
            onSaved: function (data) {
				if (data) this.$router.push({ path: '/unidademedida' });
            },
            onBack: function () {
                this.$router.go(-1);
            }
        },
		mounted() {
			this.unidadeMedidaId = +this.$route.params.id;
			this.dialogEdit = true;
        }
    };
</script>

