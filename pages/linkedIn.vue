<template>
  <Redirect :target="'https://www.linkedin.com/in/reid-merrell-ai-graphics-developer/'" :name="'LinkedIn'"/>
</template>

<script setup lang="ts">
import Redirect from '~/components/Redirect.vue'

definePageMeta({
  layout: 'redirect'
})
</script>