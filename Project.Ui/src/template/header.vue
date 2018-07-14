<template>
    <header class="app-header navbar">

        <button class="navbar-toggler sidebar-toggler d-lg-none mr-auto" type="button" @click="toggleClassBody('sidebar-show')">
            <span class="navbar-toggler-icon"></span>
        </button>

        <a class="navbar-brand" href="/home">
            <img class="navbar-brand-full" src="../assets/img/brand/logo.png" width="150" height="50" alt="Supera CRM">
            <img class="navbar-brand-minimized" src="../assets/img/brand/sygnet.png" width="50" height="50" alt="Supera CRM">
        </a>

        <button class="navbar-toggler sidebar-toggler d-md-down-none" type="button" @click="toggleClassBody('sidebar-lg-show')">
            <span class="navbar-toggler-icon"></span>
        </button>

        <ul class="nav navbar-nav ml-auto" style="margin-right:10px;">
            <li class="nav-item d-md-down-none">
                <a class="nav-link" @click="logout()">
                    {{ username }}
                    <i class="icon-logout"></i>
                </a>
            </li>
        </ul>

        <!--<button class="navbar-toggler aside-menu-toggler d-md-down-none" type="button" @click="toggleClassBody('aside-menu-lg-show')">
            <span class="navbar-toggler-icon"></span>
        </button>
        <button class="navbar-toggler aside-menu-toggler d-lg-none" type="button" @click="toggleClassBody('aside-menu-show')">
            <span class="navbar-toggler-icon"></span>
        </button>-->
    </header>
</template>
<script>

    import Global from '@/common/global'
    import Auth from '@/common/auth'

    export default {
        name: "header-app",
        data() {
            return {

            }
        },
        methods: {
            toggleClassBody(class_name) {
                document.body.classList.toggle(class_name)
            },
            logout() {
                Auth.logout()
            }
        },
        computed: {
            username() {
                return Auth.currentUser().name;
            }
        },
        mounted() {
        },

    };
</script>