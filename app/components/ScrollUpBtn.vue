<script setup>
import {ref, onMounted, onUnmounted} from 'vue'

const showScrollBtn = ref(false)

const scrollHandler = () => {
  showScrollBtn.value = window.scrollY > 300
}

const scrollToTop = () => {
  const target = document.scrollingElement || document.documentElement
  target.scrollTo({ top: 0, behavior: 'smooth' })
}

onMounted(() => {
  window.addEventListener('scroll', scrollHandler)
})

onUnmounted(() => {
  window.removeEventListener('scroll', scrollHandler)
})
</script>

<template>
  <transition name="fade">
    <button v-if="showScrollBtn" class="scroll-to-top" @click="scrollToTop" aria-label="Scroll to top"></button>
  </transition>
</template>

<style scoped>
.scroll-to-top {
  position: fixed;
  bottom: 2rem;
  right: 2rem;
  height: 48px;
  width: 48px;
  background: var(--secondary);
  background-image: url('/icons/arrow-up.svg');
  background-repeat: no-repeat;
  background-position: center;
  border: none;
  border-radius: 8px;
  box-shadow: 0 2px 6px rgba(0, 0, 0, 0.3);
  cursor: pointer;
}

.scroll-to-top:hover {
  transform: translateY(-5px);
  box-shadow: 0 4px 10px rgba(0, 191, 255, 0.5);
}

.scroll-to-top:active {
  background-color: #a3e1ff;
}

.fade-enter-active, .fade-leave-active {
  transition: opacity 0.4s ease;
}
.fade-enter-from, .fade-leave-to {
  opacity: 0;
}
</style>