<template>

    <div class="app">
        <notifications />
        <header-app />

        <div class="app-body">
            <left-menu-app />
            <router-view />
            <right-menu-app />
        </div>

        <footer-app />
    </div>

</template>
<script>

    import footerApp from '@/template/footer'
    import headerApp from '@/template/header'
    import leftMenuApp from '@/template/left-menu'
    import rightMenuApp from '@/template/right-menu'

    export default {
        name: "Template",
        components: { footerApp, headerApp, leftMenuApp, rightMenuApp },
        data() {
            return {

            };
        },
        mounted() {
            this.$eventHub.$on('show-notification', (data) => {
                this.$notify({
                    type: data.type,
                    title: data.title,
                    text: data.text,
                    duration: 10000,
                    speed: 1000
                })
                this.snackbar_color = data.type;
                this.snackbar_showing = true;
            })
        },
        beforeDestroy() {
            this.$eventHub.$off('show-notification');
        },
    };
</script>
