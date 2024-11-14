<template>
  <v-dialog
    v-model="dialog"
    max-width="500px"
  >
    <template v-slot:activator="{ props }">
      <v-btn
        prepend-icon="mdi-account-plus"
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
          :rules="cpfRules"
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

      visible: true,
      loading: false,

      cpfRules: [
        (v : any) => !!v || 'Campo obrigatório',
        (v : any) => (/^([0-9]{3}.[0-9]{3}.[0-9]{3}-[0-9]{2})|([0-9]{11})|([0-9]{9}-[0-9]{2})$/ || v.lenght == 11).test(v) || 'CPF inválido'
      ]
    }),

    watch: {
      dialog (val) {
        val || this.close()
      },
    },

    methods: {
      async registerStudent (e: SubmitEvent) {
        this.loading = true
        e.preventDefault()

        try {
          await registerStudentApi({
            name: this.itensForm.name,
            email: this.itensForm.email,
            ra: this.itensForm.ra,
            cpf: this.itensForm.cpf,
          })

          this.toast.success("Aulo cadastrado com sucesso!")
          this.close()
        } catch (e) {
          console.error("Erro:", e)
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