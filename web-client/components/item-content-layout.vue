<template>
  <div>
    <v-row>
      <v-col cols="12" lg="6" offset-lg="1" offset-xl="2" sm="7" xl="5">
        <slot name="content"></slot>
      </v-col>
      <v-col class="d-none d-sm-block" lg="4" sm="5" xl="3">
        <v-sheet class="pa-3 sticky">
          <slot name="item"></slot>
        </v-sheet>
      </v-col>
    </v-row>
    <v-dialog v-model="dialog">
      <template v-slot:activator="{on}">
        <v-btn bottom class="d-sm-none" color="blue" fab fixed right v-on="on">
          <v-icon>mdi-help</v-icon>
        </v-btn>
      </template>
      <v-sheet class="pa-2" rounded>
        <slot name="item"></slot>
      </v-sheet>
    </v-dialog>
  </div>
</template>

<script>
  export default {
    name: "item-content-layout",
    data: () => ({
      dialog: false
    })
  }
</script>

<style scoped>

</style>
