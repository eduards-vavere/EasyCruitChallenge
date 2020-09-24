<template>
<div>
<div class="panel">
    <div class="panel-heading">
      <h3 class="panel-title">
          Add new candidate
      </h3>
    </div>
    <div class="panel-body">
      <form class="form-inline">
        <div class="form-group">
          <label for="firstNameInput">First name</label>
          <input v-model="firstName" type="text" class="form-control" id="firstNameInput" :class="{'has-error': validation.hasError('firstName')}" placeholder="Jane">
          <div class="message">{{ validation.firstError('firstName') }}</div>
        </div>
        <div class="form-group">
          <label for="lastNameInput">Last name</label>
          <input v-model="lastName" type="text" class="form-control" id="lastNameInput" :class="{'has-error': validation.hasError('lastName')}" placeholder="Doe">
          <div class="message">{{ validation.firstError('lastName') }}</div>
        </div>
        <div class="form-group">
          <label for="exampleInputEmail">email</label>
          <input v-model="email" type="email" class="form-control" id="exampleInputEmail" :class="{'has-error': validation.hasError('email')}" placeholder="jane.doe@example.com">
          <div class="message">{{ validation.firstError('email') }}</div>

        </div>
        <div class="form-group">
          <label for="letterInput"  :class="{'has-error': validation.hasError('letter')}">Motivational Letter</label>
          <input v-model="letter" type="text" class="form-control" id="letterInput" :class="{'has-error': validation.hasError('letter')}">
          <div class="message">{{ validation.firstError('letter') }}</div>
        </div>
        <button type="button" class="btn" @click="addCandidate" >Send</button>
      </form>
    </div>
  </div>
  <div class="panel">
      <div class="panel-heading">
          <h3 class="panel-title">
              List of candidates
          </h3>
      </div>
      <div class="panel-body">
        <table class="table">
        <thead>
          <tr>
            <th>First name</th>
            <th>Last name</th>
            <th>email</th>
            <th colspan="2">Operations</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(candidate, i) in candidates" :key="i">
            <th scope="row">{{ candidate.firstName }}</th>
            <td>{{ candidate.lastName }}</td>
            <td>{{ candidate.email }}</td>
            <td><a href="#">Delete</a></td>
            <td><a :href="candidate.motivationLetterLink">See motivational letter</a></td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</div>
</template>

<script>
import { Validator } from 'simple-vue-validator';
import axios from 'axios';

export default {
  name: 'Candidates',
  data() {
    return {
      candidates: [],
      firstName: null,
      lastName: null,
      email: null,
      letter: null,
    };
  },
  methods: {
    addCandidate() {
      this.$validate()
        .then((success) => {
          if (success) {
            const candidate = {
              firstName: this.firstName, lastName: this.lastName, email: this.email, motivationLetterText: this.letter,
            };

            axios.post('api/candidates', candidate).then((response) => {
              if (response.data === null) {
                // DataContext in API is sometimes failing to return the variable, altough it saves it in the DB
                // I don't want to spend any more time on this challenge, so this is a workaround
                // In real life scenario I would debug it deeper and find out what's the cause :D
                // location.reload();
              }

              console.log(response);
              this.candidates.push(response.data);
            }).catch((e) => {
              alert(e);
              console.error(e);
            });

            // Reset fields
            this.firstName = null;
            this.lastName = null;
            this.email = null;
            this.letter = null;
            this.validation.reset();
          }
        });
    },
  },
  mounted() {
    axios
      .get('api/candidates')
      .then((response) => {
        this.candidates = response.data;
      })
      .catch((e) => {
        alert(e);
        console.error(e);
      });
  },
  validators: {
    firstName(value) {
      return Validator.value(value).required().minLength(2).maxLength(32);
    },
    lastName(value) {
      return Validator.value(value).required().minLength(2).maxLength(32);
    },
    email(value) {
      return Validator.value(value).required().email().maxLength(64);
    },
    letter(value) {
      return Validator.value(value).required().minLength(2).maxLength(256);
    },
  },
};
</script>
