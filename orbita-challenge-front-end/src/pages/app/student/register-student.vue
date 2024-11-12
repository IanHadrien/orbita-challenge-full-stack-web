<template>
  <v-dialog
    v-model="dialog"
    max-width="500px"
  >
    <template v-slot:activator="{ props }">
      <v-btn
        prepend-icon="$vuetify"
        color="primary"
        class="mb-5"
        height="40"
        border
        rounded="lg"
        dark
        v-bind="props"
      >
        Cadastrar Aluno
      </v-btn>
    </template>

    <v-card>
      <v-card-title class="border-b-2">
        <span class="text-h5">Cadastrar Aluno</span>
      </v-card-title>

      <form class="p-2 px-4 pt-5" @submit="registerStudent">
        <v-text-field
          v-model="itensForm.name"
          variant="underlined"
          label="Nome *"
          required
        />

        <v-text-field
          v-model="itensForm.email"
          variant="underlined"
          label="E-mail *"
          type="email" 
          required
        />

        <v-text-field
          v-model="itensForm.ra"
          variant="underlined"
          label="Registro acadêmico *"
          required
        />

        <v-text-field
          v-model="itensForm.cpf"
          variant="underlined"
          label="CPF *"
          placeholder="Informe o número do documento"
          required
        />

        <div class="flex items-center justify-end space-x-2 mt-4">
          <div>
            <v-btn
              class="text-subtitle-1 flex-grow-1 w-full sm:w-auto justify-center rounded-md bg-primary font-medium shadow-sm hover:opacity-80"
              variant="flat"
              color="error"
              @click="close"
            >
              Cancelar
            </v-btn>
          </div>

          <div>
            <v-btn
              :loading="loading"
              class="text-subtitle-1 flex-grow-1 w-full sm:w-auto justify-center rounded-md bg-primary font-medium shadow-sm hover:opacity-80"
              variant="flat"
              type="submit"
            >
              Salvar
            </v-btn>
          </div>
        </div>
      </form>
    </v-card>
  </v-dialog>
</template>

<script lang="ts">
  import { useToast } from 'vue-toastification'

  export default {
    name: 'RegisterStudent',

    setup() {
      const toast = useToast();

      return { toast }
    },
    
    data() {
      return {
        dialog: false,

        itensForm: {
          name: '',
          email: '',
          ra: '',
          cpf: '',
        },

        visible: true,
        loading: false,

        // firstNameRules: [Validação CPF],
      }
  },

    watch: {
      dialog (val) {
        val || this.close()
      },
    },

    methods: {
      registerStudent (e) {
        this.toast.success("incremented!")
        this.loading = true
        e.preventDefault()

        const data = {
          name: this.itensForm.name,
          email: this.itensForm.email,
          ra: this.itensForm.ra,
          cpf: this.itensForm.cpf,
        }

        console.log('register', data)
      },

      close () {
        this.dialog = false
      },
    }
  }
</script>