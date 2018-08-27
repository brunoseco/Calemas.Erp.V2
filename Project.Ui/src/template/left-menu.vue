<template>
    <div class="sidebar">
        <nav class="sidebar-nav">
            <ul class="nav">
                <li class="nav-item">
                    <router-link to="/home" class="nav-link">
                        <i class="nav-icon icon-home"></i> Dashboard
                    </router-link>
                </li>
                <li class="nav-title">Principal</li>
                <li class="nav-item">
                    <router-link to="/Estoque" class="nav-link">
                        <i class="nav-icon icon-people"></i> Estoque
                    </router-link>
                    <router-link to="/estoquemovimentacao" class="nav-link">
                        <i class="nav-icon "></i> estoquemovimentacao
                    </router-link>
                    <router-link to="/estoquemovimentacaocolaborador" class="nav-link">
                        <i class="nav-icon "></i> estoquemovimentacaocolaborador
                    </router-link>
                    <router-link to="/solicitacaoestoque" class="nav-link">
                        <i class="nav-icon "></i> solicitacaoestoque
                    </router-link>
                    <router-link to="/unidademedida" class="nav-link">
                        <i class="nav-icon "></i> unidademedida
                    </router-link>
                    <router-link to="/categoriaestoque" class="nav-link">
                        <i class="nav-icon"></i> categoriaestoque
                    </router-link>
                    <router-link to="/motivoestoquemovimentacao" class="nav-link">
                        <i class="nav-icon "></i> motivoestoquemovimentacao
                    </router-link>
                </li>

                <!--<li class="divider"></li>
                <li class="nav-title">Configurações</li>

                <li class="nav-item">
                    <router-link :to="'/statusnegocio'" class="nav-link">
                        <i class="nav-icon icon-arrow-right"></i> Situação do Negócio
                    </router-link>
                    <router-link :to="'/tipoemail'" class="nav-link">
                        <i class="nav-icon icon-arrow-right"></i> Tipo de E-mail
                    </router-link>
                    <router-link :to="'/tipotelefone'" class="nav-link">
                        <i class="nav-icon icon-arrow-right"></i> Tipo de Telefone
                    </router-link>
                    <router-link :to="'/tipoendereco'" class="nav-link">
                        <i class="nav-icon icon-arrow-right"></i> Tipo de Endereço
                    </router-link>
                    <router-link :to="'/tipopessoa'" class="nav-link">
                        <i class="nav-icon icon-arrow-right"></i> Tipo de Pessoa
                    </router-link>
                    <router-link :to="'/cidade'" class="nav-link">
                        <i class="nav-icon icon-arrow-right"></i> Cidade
                    </router-link>
                    <router-link :to="'/regiao'" class="nav-link">
                        <i class="nav-icon icon-arrow-right"></i> Região
                    </router-link>
                    <router-link :to="'/pais'" class="nav-link">
                        <i class="nav-icon icon-arrow-right"></i> País
                    </router-link>
                    <router-link :to="'/visibilidade'" class="nav-link">
                        <i class="nav-icon icon-arrow-right"></i> Visibilidade
                    </router-link>
                    <router-link :to="'/setor'" class="nav-link">
                        <i class="nav-icon icon-arrow-right"></i> Setor
                    </router-link>
                    <router-link :to="'/produto'" class="nav-link">
                        <i class="nav-icon icon-arrow-right"></i> Produto
                    </router-link>
                </li>-->

            </ul>
        </nav>
    </div>
</template>
<script>

    import Global from '@/common/global'
    import auth from '@/common/auth'

    export default {
        name: "left-menu-app",
        data() {
            return {

            }
        },
        methods: {
            toggleClassBody(class_name) {
                document.body.classList.toggle(class_name)
            }
        },
        computed: {

        },
        mounted() {
        },

    };
</script>