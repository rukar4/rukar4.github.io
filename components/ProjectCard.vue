<script setup>
defineProps({
  title: String,
  description: String,
  highlights: Array,
  stack: Array,
  image: String,
  video: String,
  github: String,
  demo: String,
  scripts: String,
  mediaNote: String,
  flipped: {
    type: Boolean,
    default: false
  }
})

const zoomed = ref(false)
const toggleZoom = () => {
  zoomed.value = !zoomed.value
}
</script>

<template>
  <div :class="['info-banner', { flipped }]">
    <div class="content">
      <div>
        <h2>{{ title }}</h2>
        <p>{{ description }}</p>
        <ul>
          <li v-for="highlight in highlights" :key="highlight">{{ highlight }}</li>
        </ul>
        <div class="links">
          <a v-if="github" :href="github" target="_blank" rel="noopener noreferrer">GitHub</a>
          <a v-if="demo" :href="demo" target="_blank" rel="noopener noreferrer">Live Demo</a>
          <NuxtLink v-if="scripts" :href="scripts">Scripts</NuxtLink>
        </div>
        <p v-if="stack" class="stack"><strong>Tech Stack:</strong> {{ stack.join(', ') }}</p>
      </div>
    </div>
    <div class="media">
      <div class="media-clip">
        <img
            v-if="image"
            :src="image"
            alt="{{ title }}"
            @click="toggleZoom"
            class="clickable"
        />
        <video v-else-if="video" :src="video" muted controls/>
        <div v-if="mediaNote" class="media-note">{{ mediaNote }}</div>
      </div>
    </div>
  </div>

  <div v-if="zoomed" class="zoom-overlay" @click="toggleZoom">
    <img :src="image" alt="{{ title }}" class="zoomed-img"/>
  </div>
</template>

<style scoped>
.content {
  display: flex;
  flex-direction: column;
  padding: 0 clamp(2rem, 8vw, 12rem) 0 0;
  flex: 1;
}

.info-banner.flipped .content {
  align-items: flex-end;
  padding: 0 clamp(2rem, 8vw, 12rem);
}

.stack {
  padding-top: 0.5rem;
}

.links a {
  margin-right: 1rem;
  text-decoration: underline;
}

.clickable {
  cursor: zoom-in;
}

.zoom-overlay {
  position: fixed;
  top: 0;
  left: 0;
  width: 100vw;
  height: 100vh;
  background-color: rgba(0, 0, 0, 0.85);
  display: flex;
  align-items: center;
  justify-content: center;
  z-index: 9999;
  cursor: zoom-out;
}

.zoomed-img {
  max-width: 90%;
  max-height: 90%;
  border-radius: 8px;
  box-shadow: 0 0 20px rgba(0, 191, 255, 0.8);
  transition: transform 0.3s ease;
}

.media-note {
  font-style: italic;
  color: #bebebe;
  margin-top: 0.5rem;
}
</style>