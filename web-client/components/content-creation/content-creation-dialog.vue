<template>
  <v-dialog
    :value="active"
    persistent
    width="700"
  >
    <template v-slot:activator="{on}">
      <v-menu offset-y>
        <template v-slot:activator="{on, attrs}">
          <v-btn depressed v-bind="attrs" v-on="on">
            Create
          </v-btn>
        </template>
        <v-list>
          <v-list-item :key="`ccd-menu-${i}`" @click="activate({component: item.component})" v-for="(item, i) in menuItems">
            <v-list-item-title>{{item.title}}</v-list-item-title>
          </v-list-item>
        </v-list>
      </v-menu>
    </template>

    <div v-if="component">
      <component :is="component"></component>
    </div>

  </v-dialog>
</template>

<script>
  import { mapMutations, mapState} from 'vuex'
  import TrickSteps from "./trick-steps";
  import SubmissionSteps from "./submission-steps";
  import DifficultyForm from "./difficulty-form";
  import CategoryForm from "./category-form";


  export default {
    name: "content-creation-dialog",
    components: {CategoryForm, DifficultyForm, SubmissionSteps, TrickSteps},
    computed: {
      ...mapState('video-upload', ['active', 'component']),
      menuItems() {
        return [
          {component: TrickSteps, title: "Trick"},
          {component: SubmissionSteps, title: "Submission"},
          {component: CategoryForm, title: "Category"},
          {component: DifficultyForm, title: "Difficulty"},
        ]
      }
    },
    methods: mapMutations('video-upload', ['activate']),
  }
</script>

<style scoped>

</style>
