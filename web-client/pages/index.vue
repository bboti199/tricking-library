<template>
  <div>
    <div v-for="s in sections">
      <div class="d-flex align-center flex-column">
        <p class="text-h5">{{ s.title }}</p>
        <div>
          <v-btn :key="`${item.title}-${item.id}`" :to="s.routeFactory(item.id)" class="mx-1"
                 v-for="item in s.collection">{{item.name}}
          </v-btn>
        </div>
      </div>
      <v-divider class="my-5"></v-divider>
    </div>
  </div>
</template>

<script>
  import {mapState} from 'vuex'

  export default {
    computed: {
      ...mapState('tricks', ['tricks', 'categories', 'difficulties']),
      sections() {
        return [
          {collection: this.tricks, title: 'Tricks', routeFactory: (id) => `/trick/${id}`},
          {collection: this.categories, title: 'Categories', routeFactory: (id) => `/category/${id}`},
          {collection: this.difficulties, title: 'Difficulties', routeFactory: (id) => `/difficulty/${id}`},
        ]
      }
    }
  }
</script>
