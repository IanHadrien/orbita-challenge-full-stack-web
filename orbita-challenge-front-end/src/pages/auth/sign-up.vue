<template>
  <main class="md:grid min-h-screen grid-cols-2 ">
    <Logo />

    <section class="border">
      <div class="text-center py-16">
        <v-icon icon="mdi-star-four-points-circle-outline" size="x-large"></v-icon>

        <h2 class="text-4xl pb-2 pt-8 font-semibold">
          Criar conta!
        </h2>
        <p>Por favor, insira seus dados</p>
      </div>

      <form ref="form" class="m-auto w-3/4 space-y-2" @submit="register">
        <v-text-field
          v-model="email"
          label="Email"
          variant="underlined"
          required
        />

        <v-text-field
          v-model="password"
          :counter="10"
          label="Senha"
          :type="showPassword ? 'text' : 'password'"
          variant="underlined"
          required
          :append-icon="showPassword ? 'mdi-eye-off' : 'mdi-eye'"
          @click:append="togglePasswordVisibility"
        />

        <div class="d-flex flex-column">
          <v-btn
            class="mt-4"
            height="50"
            color="#2D2C2C"
            rounded="xl"
            block
            type="submit"
            :loading="loading"
          >
            Finalizar cadastro
          </v-btn>

          <v-btn
            class="mt-4"
            rounded="xl"
            border
            height="50"
            color="#E9E9E9"
            block
            :to="{ name: 'SignIn' }"
          >
            Acessar
          </v-btn>
        </div>
      </form>
    </section>
  </main>
</template>

<script lang="ts">
  import { signUpApi } from "@/api/account/sign-up"
  import Logo from "../../components/logo.vue"
  import { useToast } from 'vue-toastification'

  export default {
    name: "SignUp",

    setup() {
      const toast = useToast()
      return { toast }
    },

    data: () => ({
      email: '',
      password: '',
      loading: false,
      showPassword: false,
    }),

    components: {
      Logo
    },

    methods: {
      async register(e: Event) {
        this.loading = true
        e.preventDefault()

        try {
          const response = await signUpApi({
            email: this.email,
            password: this.password,
          })

          const token = response.token

          localStorage.setItem("@authToken", token);
          this.$router.push("/students");

          this.toast.success("Usuário cadastrado com sucesso!")
        } catch (e) {
          this.toast.error('Falha ao usuário estudantes.')
        } finally {
          this.loading = false
        }
      },

      togglePasswordVisibility() {
        this.showPassword = !this.showPassword
      }
    },
  }
</script>