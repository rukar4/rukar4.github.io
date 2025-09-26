<script setup>
import ScrollUpBtn from "~/components/ScrollUpBtn.vue";
</script>

<template>
  <div class="page">
    <header>
      <div class="banner">
        <h1>
          <NuxtLink to="/multi-page" class="title">
            Reid Merrell
          </NuxtLink>
        </h1>

        <div class="nav-link">
          <NuxtLink to="/projects/full_stack">
            <span/>
            Full Stack
          </NuxtLink>
        </div>

        <div class="nav-link">
          <NuxtLink to="/projects/ai">
            <span/>
            Artificial Intelligence
          </NuxtLink>
        </div>

        <div class="nav-link">
          <NuxtLink to="/projects/graphics">
            <span/>
            Computer Graphics
          </NuxtLink>
        </div>
      </div>
      <hr>
    </header>

    <main>
      <slot/>
      <ScrollUpBtn/>
    </main>

    <FooterContent/>
  </div>
</template>

<style scoped>
span {
  position: absolute;
  width: 100%;
  height: 100%;
  top: 0;
  left: 0;
  z-index: 1;
}

.title {
  color: inherit;
  text-decoration: none;
  cursor: pointer;
}

.title:hover {
  color: inherit;
  text-decoration: none;
}

.nav-link {
  position: relative;
  font-size: 1.3rem;
  padding: 1rem;
  cursor: pointer;
  transition: box-shadow 0.3s ease, background-color 0.3s ease;
  border-radius: 8px;
}

.nav-link :deep(a) {
  display: block;
  width: 100%;
  height: 100%;
  text-decoration: none;
  color: inherit;
  cursor: pointer;
}

.nav-link:hover {
  background-color: var(--primary);
  box-shadow: 0 0 10px rgba(0, 191, 255, 0.5);
}

@media (max-width: 1500px) {
  .banner {
    flex-direction: column;
    align-items: center;
  }

  .title {
    padding: 0;
  }

  .nav-link {
    width: 100%;
    text-align: center;
    padding: 0.5rem 0.5rem;
  }
}
</style>
