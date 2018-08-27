
const routers = [
    { path: 'unidademedida', name: 'Unidade de Medida', component: function (resolve) { require(['@/views/unidademedida'], resolve) } },
    { path: 'unidademedida/create', name: 'Novo Unidade de Medida', component: function (resolve) { require(['@/views/unidademedida/create'], resolve) } },
    { path: 'unidademedida/edit/:id', name: 'Editar Unidade de Medida', component: function (resolve) { require(['@/views/unidademedida/edit'], resolve) } },
    { path: 'estoquemovimentacaocolaborador', name: 'Colaborador', component: function (resolve) { require(['@/views/estoquemovimentacaocolaborador'], resolve) } },
    { path: 'estoquemovimentacaocolaborador/create', name: 'Novo Colaborador', component: function (resolve) { require(['@/views/estoquemovimentacaocolaborador/create'], resolve) } },
    { path: 'estoquemovimentacaocolaborador/edit/:id', name: 'Editar Colaborador', component: function (resolve) { require(['@/views/estoquemovimentacaocolaborador/edit'], resolve) } },
    { path: 'categoriaestoque', name: 'Categoria de Estoque', component: function (resolve) { require(['@/views/categoriaestoque'], resolve) } },
    { path: 'categoriaestoque/create', name: 'Novo Categoria de Estoque', component: function (resolve) { require(['@/views/categoriaestoque/create'], resolve) } },
    { path: 'categoriaestoque/edit/:id', name: 'Editar Categoria de Estoque', component: function (resolve) { require(['@/views/categoriaestoque/edit'], resolve) } },
    { path: 'solicitacaoestoque', name: 'Solicitação de Estoque', component: function (resolve) { require(['@/views/solicitacaoestoque'], resolve) } },
    { path: 'solicitacaoestoque/create', name: 'Novo Solicitação de Estoque', component: function (resolve) { require(['@/views/solicitacaoestoque/create'], resolve) } },
    { path: 'solicitacaoestoque/edit/:id', name: 'Editar Solicitação de Estoque', component: function (resolve) { require(['@/views/solicitacaoestoque/edit'], resolve) } },
    { path: 'estoquemovimentacao', name: 'Movimentação de Estoque', component: function (resolve) { require(['@/views/estoquemovimentacao'], resolve) } },
    { path: 'estoquemovimentacao/create', name: 'Novo Movimentação de Estoque', component: function (resolve) { require(['@/views/estoquemovimentacao/create'], resolve) } },
    { path: 'estoquemovimentacao/edit/:id', name: 'Editar Movimentação de Estoque', component: function (resolve) { require(['@/views/estoquemovimentacao/edit'], resolve) } },
    { path: 'motivoestoquemovimentacao', name: 'Motivo de Movimentação de Estoque', component: function (resolve) { require(['@/views/motivoestoquemovimentacao'], resolve) } },
    { path: 'motivoestoquemovimentacao/create', name: 'Novo Motivo de Movimentação de Estoque', component: function (resolve) { require(['@/views/motivoestoquemovimentacao/create'], resolve) } },
    { path: 'motivoestoquemovimentacao/edit/:id', name: 'Editar Motivo de Movimentação de Estoque', component: function (resolve) { require(['@/views/motivoestoquemovimentacao/edit'], resolve) } },
    { path: 'estoque', name: 'Estoque', component: function (resolve) { require(['@/views/estoque'], resolve) } },
    { path: 'estoque/create', name: 'Novo Estoque', component: function (resolve) { require(['@/views/estoque/create'], resolve) } },
    { path: 'estoque/edit/:id', name: 'Editar Estoque', component: function (resolve) { require(['@/views/estoque/edit'], resolve) } },

];

export default routers