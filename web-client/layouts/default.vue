<template>
  <v-app dark>
    <v-app-bar app dense>
      <nuxt-link class="text--primary" style="text-decoration: none;" to="/">
        <v-toolbar-title>Tricking Library</v-toolbar-title>
      </nuxt-link>

      <v-spacer></v-spacer>
      <v-btn depressed to="/moderation">Moderation</v-btn>
      <content-creation-dialog></content-creation-dialog>
    </v-app-bar>

    <v-main>
      <v-container>
        <nuxt/>
      </v-container>
    </v-main>
  </v-app>
</template>

<script>
  import ContentCreationDialog from "../components/content-creation/content-creation-dialog";

  export default {
    components: {ContentCreationDialog},
  }
</script>
