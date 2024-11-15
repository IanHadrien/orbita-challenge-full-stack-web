<template>
  <div class="mr-5">
    <v-menu
      min-width="200px"
      rounded
    >
      <template v-slot:activator="{ props }">
        <v-btn
          icon
          v-bind="props"
        >
          <v-avatar
            color="#2D2C2C"
            size="large"
          >
            <span class="text-h5">{{ user.initials }}</span>
          </v-avatar>
        </v-btn>
      </template>
      <v-card>
        <v-card-text>
          <div class="mx-auto text-center">
            <v-avatar
              color="#2D2C2C"
            >
              <span class="text-h5">{{ user.initials }}</span>
            </v-avatar>
            <p class="text-caption mt-1">
              {{ user.email }}
            </p>

            <v-btn
              rounded
              class="mt-4"
              height="40"
              color="#2D2C2C"
              block
              @click="logout"
            >
              Logout
            </v-btn>

          </div>
        </v-card-text>
      </v-card>
    </v-menu>
  </div>
</template>

<script lang="ts">
  export default {
    name: 'Avatar',

    data: () => ({
      user: {
        initials: 'JD',
        email: 'john.doe@doe.com',
      },
    }),

    mounted() {
      this.getDataUser()
    },

    methods: {
      getDataUser() {
        const storedData = localStorage.getItem("@authData");

        if (storedData) {
          const parsedData = JSON.parse(storedData);

          if (parsedData.email) {
            this.user.email = parsedData.email;
          }

          if (parsedData.email) {
            const initials = parsedData.email
              .split('@')[0]
              .slice(0, 2)
              .toUpperCase();
            this.user.initials = initials;
          }
        }
      },

      logout() {
        localStorage.removeItem("@authData")
        this.$router.push("/sign-in")
      },
    }
  }
</script>