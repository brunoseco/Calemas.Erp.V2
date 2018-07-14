import Vue from 'vue'
import Pikaday from 'pikaday'
import 'pikaday/scss/pikaday.scss'
import { setTimeout } from 'timers';

Vue.directive('datepicker', {
    twoWay: true,
    bind: (el, binding, vnode) => {
        var picker = new Pikaday({
            field: el,
            format: 'DD/MM/YYYY',
            onSelect: (date) => {
                console.log(picker.toString())
                setVModelValue(picker.toString(), vnode)
            },
            i18n: {
                previousMonth: 'Mês Anterior',
                nextMonth: 'Mês Seguinte',
                months: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
                weekdays: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado'],
                weekdaysShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sab']
            }
        });


        function findVModelName(vnode) {
            return vnode.data.directives.find(function (o) {
                return o.name === 'model';
            }).expression;
        }

        function setVModelValue(value, vnode) {
            var prop = findVModelName(vnode)
            eval('vnode.context.' + prop + ' = ' + '"' + value + '"')
        }
    },
    update: (el, binding, vnode) => {
        //if (el.value) {
        //    var dateParts = el.value.split("/");
        //    if (dateParts.length > 0) {
        //        var dateObject = new Date(dateParts[2], dateParts[1] - 1, dateParts[0]);
        //        var picker = new Pikaday({ field: el });
        //        picker.setDate(dateObject);
        //    }
        //}
    }

})