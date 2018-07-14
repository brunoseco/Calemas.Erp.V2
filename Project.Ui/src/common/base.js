
import pagination from '@/common/components/pagination'

export default {
    components: { pagination },
    data: () => ({
        apiKeyEditor: "dv6x95ukpmh4i9xpp1l7bhwlld97vlz7409nkco50m14ozj1",
        configEditorSimple: {
            selector: "textarea",
            height: 150,

            language_url: '/js/tinymce-pt_br.js',

            plugins: [
                "advlist autolink autosave link image lists charmap print preview hr anchor pagebreak",
                "searchreplace wordcount visualblocks visualchars code fullscreen insertdatetime media nonbreaking table",
                "table contextmenu directionality emoticons template textcolor paste fullpage textcolor colorpicker textpattern"
            ],

            toolbar1: "styleselect formatselect fontselect fontsizeselect | cut copy paste | bullist numlist | outdent indent blockquote | undo redo",
            toolbar2: "bold italic underline strikethrough | forecolor backcolor | alignleft aligncenter alignright alignjustify | table charmap emoticons | hr removeformat | link unlink anchor image media code | print fullscreen",

            menubar: false,
            toolbar_items_size: 'small',


        },
        configEditor: {
            selector: "textarea",
            height: 450,

            language_url: '/js/tinymce-pt_br.js',

            plugins: [
                "advlist autolink autosave link image lists charmap print preview hr anchor pagebreak",
                "searchreplace wordcount visualblocks visualchars code fullscreen insertdatetime media nonbreaking table",
                "table contextmenu directionality emoticons template textcolor paste fullpage textcolor colorpicker textpattern"
            ],

            toolbar1: "styleselect formatselect fontselect fontsizeselect | cut copy paste | bullist numlist | outdent indent blockquote | undo redo",
            toolbar2: "bold italic underline strikethrough | forecolor backcolor | alignleft aligncenter alignright alignjustify | table charmap emoticons | hr removeformat | link unlink anchor image media code | print fullscreen",

            menubar: false,
            toolbar_items_size: 'small',
        },

        mask_data: '##/##/####',
        mask_cpf: '###.###.###-##',
        mask_rg: '##.###.###-#',
        mask_tel: '####-####',
        mask_cel: '#####-####',
        money: {
            decimal: ',',
            thousands: '.',
            prefix: 'R$ ',
            suffix: ' #',
            precision: 2,
            masked: false
        },
        teste: {
            decimal: ',',
            thousands: '.',
            precision: 2,
        }
    }),
    methods: {

        defaultPageChanged: function (filter, index) {
            filter.pageIndex = index;
            return filter;
        },
        defaultOrderBy: function (filter, field) {
            let type = 0;
            if (filter.orderByType == 0) type = 1;
            filter.orderFields = field;
            filter.orderByType = type;
            filter.isOrderByDynamic = true;
            return filter;
        },

        defaultSuccessResult: function (msg) {
            this.hideLoading();
            this.$eventHub.$emit('show-notification', {
                type: 'success',
                title: 'Sucesso',
                text: msg
            })
        },
        defaultErrorResult: function (err) {
            this.hideLoading();
            if (err.data && err.data.errors) {
                for (var i = 0; i < err.data.errors.length; i++) {
                    this.$eventHub.$emit('show-notification', {
                        type: 'error',
                        title: 'Atenção',
                        text: err.data.errors[i]
                    })
                }
            }
                
            else
                this.$eventHub.$emit('show-notification', {
                    type: 'error',
                    title: 'Atenção',
                    text: err
                })
        },

        showLoading: function () {
            this.isLoading = true;
        },
        hideLoading: function () {
            this.isLoading = false;
        },
        failLoading: function () {
            this.isLoading = false;
        },

    },
}
