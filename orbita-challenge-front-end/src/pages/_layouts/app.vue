<template>
  <div>
    <v-navigation-drawer v-model="isDrawerOpen">
      <div class="text-3xl font-bold underline pl-10 pt-4 pb-5 border-b-2">
        <v-img
          cover
          src="https://maisaedu.com.br/hubfs/site-grupo-a/logo-mais-a-educacao.svg"
          width="75%"
        ></v-img>
      </div>

      <v-list
        class="mx-auto p-0"
        max-width="256"
      >
        <v-list-item
          prepend-icon="mdi-account"
          title="Alunos"
          link
          to="/students"
        />
      </v-list>
    </v-navigation-drawer>

    <v-app-bar flat class="border-b">
      <v-app-bar-nav-icon @click="isDrawerOpen = !isDrawerOpen"></v-app-bar-nav-icon>
      <v-app-bar-title class="tracking-tight">
        Módulo Acadêmico
      </v-app-bar-title>

      <template #append>
        <DarkMode />

        <Avatar />
      </template>
    </v-app-bar>
    <router-view />
  </div>
</template>

<script lang="ts">
  import Avatar from '@/components/avatar.vue'
  import DarkMode from '@/components/mode-toggle.vue'

  export default {
    name: "LayoutApp",

    data: () => ({
      isDrawerOpen: true,
    }),

    components: {
      Avatar,
      DarkMode
    }
  }
</script>