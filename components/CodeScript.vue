<script setup>
import { onMounted, ref, nextTick } from 'vue'
import Prism from 'prismjs'
import 'prismjs/themes/prism-tomorrow.css'
import 'prismjs/components/prism-csharp' // make sure this matches your prop!

const props = defineProps({
  title: String,
  description: String,
  filename: String,
  language: String,
})

const code = ref('')

onMounted(async () => {
  const response = await fetch(`/scripts/${props.filename}`)
  const rawCode = await response.text()

  code.value = Prism.highlight(rawCode, Prism.languages.csharp, props.language)
})

</script>

<template>
  <div class="code-script">
    <h2>{{ title }}</h2>
    <p>{{ description }}</p>
    <pre><code :class="`language-${language}`" v-html="code" /></pre>
  </div>
</template>

<style scoped>
.code-script {
  margin: 1rem;
}

pre {
  background-color: rgba(48, 48, 48, 0.5);
  margin: 2rem;
  padding: 1rem;
  border-radius: 8px;
  overflow: auto;
  font-size: 0.9rem;
  max-height: 50vh;
}

code {
  display: block;
  white-space: pre;
}

@media (max-width: 800px) {
  .code-script {
    margin: 0;
    padding: 0;
    align-items: center;
  }

  pre {
    font-size: 0.8rem;
    width: 90%;
    max-height: 90vh;
    justify-self: center;
  }
}
</style>