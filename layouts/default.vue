<script setup>
import ScrollUpBtn from "~/components/ScrollUpBtn.vue";
</script>

<template>
  <div class="page">
    <header>
      <div class="banner">
        <h1>
          <NuxtLink to="/" class="title">
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

    <footer>
      <hr>
      <p>
        Connect with me on
        <a href="https://www.linkedin.com/in/reid-merrell-ai-graphics-developer/"
           target="_blank" rel="noopener noreferrer">LinkedIn</a>
      </p>
      <a href="https://github.com/rukar4/rukar4.github.io" target="_blank" rel="noopener noreferrer">Github</a>
      <p>Reid Merrell 2025</p>
    </footer>
  </div>
</template>

<style scoped>
.page {
  display: flex;
  flex-direction: column;
  min-height: 100vh;
  scroll-behavior: smooth;
}

main {
  flex: 1;
}

footer {
  text-align: center;
  padding: 1rem 0;
  margin-top: auto;
}

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
  background-color: rgba(0, 191, 255, 0.1);
  box-shadow: 0 0 10px rgba(0, 191, 255, 0.5);
}

@media (max-width: 768px) {
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
