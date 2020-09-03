<template>
  <div>
    <div class="my-2">
      <p class="mb-1" v-html="comment.htmlContent"></p>
      <v-btn small text v-if="!replying" @click="replying = true">Reply</v-btn>
      <v-btn small text v-if="$listeners['load-replies']" @click="$emit('load-replies')">Show replies</v-btn>
    </div>

    <comment-input label="Reply" @send="(c) => $emit('send', c)" @cancel="replying = false" v-if="replying" />
  </div>
</template>

<script>
  import CommentInput from "./comment-input";
  export default {
    name: "comment-body",
    components: {CommentInput},
    props: {
      comment: {
        required: true,
        type: Object
      }
    },
    data: () => ({
      replying: false
    })
  }
</script>

<style scoped>

</style>
