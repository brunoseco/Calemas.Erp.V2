
const routers = [
    { path: 'unidademedida', name: 'Unidade de Medida', component: function (resolve) { require(['@/views/unidademedida'], resolve) } },
    { path: 'unidademedida/create', name: 'Novo Unidade de Medida', component: function (resolve) { require(['@/views/unidademedida/create'], resolve) } },
    { path: 'unidademedida/edit/:id', name: 'Editar Unidade de Medida', component: function (resolve) { require(['@/views/unidademedida/edit'], resolve) } },

];

export default routers