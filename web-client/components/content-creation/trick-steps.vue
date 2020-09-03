<template>
  <v-card>
    <v-card-title>
      Create Trick
      <v-spacer></v-spacer>
      <v-btn icon @click="close">
        <v-icon>mdi-close</v-icon>
      </v-btn>
    </v-card-title>

    <v-stepper class="rounded-0" v-model="step">
      <v-stepper-header class="elevation-0">
        <v-stepper-step :complete="step > 1" step="1">Trick Information</v-stepper-step>
        <v-divider></v-divider>
        <v-stepper-step step="2">Review</v-stepper-step>
      </v-stepper-header>

      <v-stepper-items>
        <v-stepper-content class="pt-0" step="1">
          <div>
            <v-text-field label="Name" v-model="form.name"></v-text-field>
            <v-text-field label="Description" v-model="form.description"></v-text-field>
            <v-select :items="difficultyItems" label="Difficulty" v-model="form.difficulty"></v-select>
            <v-select :items="tricksItems" chips deletable-chips label="Prerequisites" multiple small-chips
                      v-model="form.prerequisites"></v-select>
            <v-select :items="tricksItems" chips deletable-chips label="Progressions" multiple small-chips
                      v-model="form.progressions"></v-select>
            <v-select :items="categoryItems" chips deletable-chips label="Categories" multiple small-chips
                      v-model="form.categories"></v-select>

            <v-btn @click="step++">Next</v-btn>
          </div>
        </v-stepper-content>

        <v-stepper-content class="pt-0 d-flex justify-center" step="2">
          <div>
            <v-btn @click="save">Save</v-btn>
          </div>
        </v-stepper-content>
      </v-stepper-items>
    </v-stepper>
  </v-card>

</template>

<script>
  import {mapActions, mapMutations, mapState, mapGetters} from 'vuex'
  import {close} from "./shared";

  export default {
    name: "trick-steps",
    mixins: [close],
    data: () => ({
      step: 1,
      form: {
        name: "",
        description: "",
        difficulty: "",
        prerequisites: [],
        progressions: [],
        categories: [],
      },
      testData: [
        {text: 'Foo', value: 1},
        {text: 'Bar', value: 2},
        {text: 'Baz', value: 3},
      ]
    }),
    computed: {
      ...mapGetters('tricks', ['categoryItems', 'difficultyItems', 'tricksItems'])
    },
    methods: {
      ...mapActions('tricks', ['createTrick']),
      async save() {
        await this.createTrick({form: this.form});
        this.close();
      },
    }
  }
</script>

<style scoped>

</style>
