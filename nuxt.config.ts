// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  ssr: false,
  app: {
    baseURL: '/',
    head: {
      title: 'Reid Merrell - Software Engineer',
      meta: [
        { name: 'viewport', content: 'width=device-width, initial-scale=1' },
        { name: 'description', content: 'Portfolio website containing computer science projects' }
      ],
      link: [
        { rel: 'icon', type: 'image/jpeg', href: '/rukar4.github.io/cpu-graphics.png' }
      ]
    }
  },
  css: [
    '@/style.css',
  ],
  nitro: {
    preset: 'static'
  },
  devtools: { enabled: true }
})
