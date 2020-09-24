import Vue from 'vue';
import SimpleVueValidation from 'simple-vue-validator';
import App from './App.vue';

Vue.use(SimpleVueValidation);
Vue.config.productionTip = false;

new Vue({
  render: h => h(App),
}).$mount('#app');
