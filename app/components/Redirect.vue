<template>
  <div class="redirecting">
    <p>Redirecting to {{ name }}…</p>
    <p>
      If you are not redirected,
      <a :href="target" rel="noopener noreferrer">click here</a>.
    </p>
  </div>
</template>

<script setup lang="ts">
const props = defineProps({
  target: {
    type: String
  },
  name : {
    type: String
  }
})

import { onMounted } from 'vue'

onMounted(() => {
  window.location.href = props.target
})
</script>

<style scoped>
.redirecting {
  display: flex;
  flex-direction: column;
  justify-content: center;
  justify-self: center;
  align-items: center;
  font-size: 1.2rem;
}
</style>
