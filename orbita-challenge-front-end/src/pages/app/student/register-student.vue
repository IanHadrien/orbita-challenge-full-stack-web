<template>
  <v-dialog
    v-model="dialog"
    max-width="500px"
  >
    <template v-slot:activator="{ props }">
      <v-btn
        prepend-icon="mdi-account-plus"
        color="#2D2C2C"
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
          :error-messages="errors.Name"
          label="Nome *"
          required
        />

        <v-text-field
          v-model="itensForm.email"
          variant="underlined"
          :error-messages="errors.Email"
          label="E-mail *"
          type="email" 
          required
        />

        <v-text-field
          v-model="itensForm.ra"
          variant="underlined"
          :error-messages="errors.RA"
          label="Registro acadêmico *"
          required
        />

        <v-text-field
          v-model="itensForm.cpf"
          variant="underlined"
          :error-messages="errors.CPF"
          label="CPF *"
          placeholder="Informe o número do documento"
          required
        />

        <div class="flex items-center justify-end space-x-2 mt-4">
          <div>
            <v-btn
              class="text-subtitle-1 flex-grow-1 w-full sm:w-auto justify-center rounded-md font-medium shadow-sm hover:opacity-80"
              variant="flat"
              color="#CE002E"
              @click="close"
            >
              Cancelar
            </v-btn>
          </div>

          <div>
            <v-btn
              :loading="loading"
              class="text-subtitle-1 flex-grow-1 w-full sm:w-auto justify-center rounded-md font-medium shadow-sm hover:opacity-80"
              variant="flat"
              color="#2D2C2C"
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
  import { registerStudentApi } from '@/api/student/register-student'
  import { useToast } from 'vue-toastification'

  export default {
    name: 'RegisterStudent',

    setup() {
      const toast = useToast();

      return { toast }
    },
    
    data: () => ({
      dialog: false,

      itensForm: {
        name: '',
        email: '',
        ra: '',
        cpf: '',
      },

      errors: {
        Name: null,
        Email: null,
        RA: null,
        CPF: null,
      },

      visible: true,
      loading: false,
    }),

    methods: {
      async registerStudent (e: Event) {
        this.loading = true
        e.preventDefault()

        this.errors = {
          Name: null,
          Email: null,
          RA: null,
          CPF: null,
        }

        try {
          await registerStudentApi({
            name: this.itensForm.name,
            email: this.itensForm.email,
            ra: this.itensForm.ra,
            cpf: this.itensForm.cpf,
          })

          this.toast.success("Aulo cadastrado com sucesso!")

          this.$emit("register-success")
          this.close()
        } catch (error: any) {
          const serverErrors = error?.response?.data?.errors;
        
          if (serverErrors) {
            for (const field in serverErrors) {
              this.errors[field] = serverErrors[field][0]
            }
          }

          this.toast.error('Falha ao cadastrar estudantes.')
        } finally {
          this.loading = false
        }
      },

      close () {
        this.dialog = false
        this.itensForm = {
          name: '',
          email: '',
          ra: '',
          cpf: '',
        }
      },
    }
  }
</script>