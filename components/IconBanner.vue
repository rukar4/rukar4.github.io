<script setup>
defineProps({
  links: {
    type: Array,
    required: true,
    default: () => []
  }
})
</script>

<template>
  <div class="link-banner">
    <a v-for="link in links" :key="link.label" :href="link.url" class="link-item">
      <div class="icon" :style="{ backgroundImage: `url(${link.icon})` }"></div>
      <span class="label">{{ link.label }}</span>
    </a>
  </div>
</template>

<style scoped>
.link-banner {
  display: flex;
  justify-content: space-around;
  background-color: var(--primary);
  border-radius: 12px;
  padding: 3rem;
  margin: 4rem 2rem 2rem;
  position: relative;
  text-align: center;
}

.link-item {
  flex: 1;
  position: relative;
  display: flex;
  flex-direction: column;
  align-items: center;
  text-decoration: none;
}

.icon {
  position: absolute;
  top: -5rem;
  width: 5rem;
  height: 5rem;
  background: var(--secondary);
  background-size: 70%;
  background-position: center;
  background-repeat: no-repeat;
  border-radius: 50%;
  padding: 0.5rem;
  box-shadow: 0 2px 6px rgba(0, 0, 0, 0.3);
  transition: transform 0.3s ease, box-shadow 0.3s ease;
}

.link-item:hover .icon {
  transform: translateY(-5px);
  box-shadow: 0 4px 10px rgba(0, 191, 255, 0.5);
}

.label {
  margin-top: 2rem;
  font-weight: bold;
  text-decoration: none;
}

@media (max-width: 1500px) {
  .link-banner {
    flex-direction: column;
    align-items: center;
    gap: 2rem;
  }

  .icon {
    position: relative;
    width: 4rem;
    height: 4rem;
    top: 0;
  }

  .label {
    margin-top: 0.5rem;
  }
}
</style>