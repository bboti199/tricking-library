<template>
  <div>
    <v-text-field
      @keydown.ctrl.enter="$emit('send', content)"
      clearable
      label="Comment"
      v-model="content"></v-text-field>
    <v-btn @click="$emit('cancel')" v-if="$listeners['cancel']">Cancel</v-btn>
    <v-btn :disabled="!content" @click="$emit('send', content)">{{ label }}</v-btn>
  </div>
</template>

<script>
  export default {
    props: {
      label: {
        required: false,
        type: String,
        default: "Send"
      }
    },
    data: () => ({
      content: ""
    })
  }
</script>

<style scoped>

</style>
