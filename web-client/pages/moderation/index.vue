<template>
    <div>
      <v-btn :to="`/moderation/${item.id}/${item.type}/${item.target}`" :key="item.id" v-for="item in items">
        {{ item.target }}
      </v-btn>
    </div>
</template>

<script>
    export default {
        data: () => ({
          items: []
        }),
      async fetch() {
          this.items = await this.$axios.$get("/api/moderation-items")
      }
    }
</script>

<style scoped>

</style>
