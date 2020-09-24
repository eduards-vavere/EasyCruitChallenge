<template>
  <div id="app">
    <header class="navbar navbar-default" id="nc4navTopMain" role="navigation">
      <div class="navbar-header">
        <div class="navbar-brand dropdown">
          <a class="dropdown-toggle"
              href="#"
              data-toggle="dropdown"
              role="button"
              aria-expanded="false"
              aria-label="EasyCruit challenge">
              EasyCruit challenge
              <span class="caret"></span>
          </a>
        </div>
      </div>
    </header>
    <Candidates/>
    <link rel="stylesheet" href="https://nc4-visma.s3.eu-north-1.amazonaws.com/latest/dist/css/nc.min.css">
  </div>
</template>

<script>
import Candidates from './components/Candidates.vue';

export default {
  name: 'app',
  components: {
    Candidates,
  },
};
</script>
