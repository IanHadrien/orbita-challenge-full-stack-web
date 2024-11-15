<template>
  <div class="welcome-message">
    Bem-vindo ao módulo acadêmico!
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'

export default defineComponent({
  setup () {
    

    return {
      name: 'About',
    }
  }
})
</script>

<style scoped>
.welcome-message {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
  font-size: 2rem;
  font-weight: bold;
}
</style>