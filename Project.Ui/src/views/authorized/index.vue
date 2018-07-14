<template>
    <div class="app flex-row align-items-center">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-md-6">
                    <div class="clearfix">
                        <h1>Login realizado com sucesso!</h1>
                        <p class="text-muted">Estamos carregando as informações do seu usuário, você será redirecionado em breve.</p>
                    </div>
                </div>
            </div>
        </div>
    </div>

</template>
<script>

    import Auth from '@/common/auth'

    export default {
        name: 'authorized',
        mounted() {
            Auth.verifyLogin();
        }
    }
</script>
