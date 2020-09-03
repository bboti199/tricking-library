<template>
  <div>
    <comment-input @send="(c) => $emit('send', c)" label="comment"/>

    <v-divider class="my-5"/>

    <comment :comment="comment" :key="comment.id" v-for="comment in comments"/>
  </div>
</template>

<script>
  import CommentInput from "./comment-input";
  import Comment from "./comment";

  export default {
    name: "comment-section",
    components: {Comment, CommentInput},
    props: {
      comments: {
        required: true,
        type: Array,
      }
    }
  }
</script>

<style scoped>

</style>
