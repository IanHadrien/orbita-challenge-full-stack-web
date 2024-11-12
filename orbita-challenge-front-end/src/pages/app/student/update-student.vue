<template>
  <v-dialog
    v-model="dialog"
    max-width="500px"
  >
    <template v-slot:activator="{ props }">
      <v-btn 
        density="compact" 
        class="me-2"
        rounded
        icon="mdi-pencil-outline" 
        v-bind="props"
      />
    </template>

    <v-card>
      <v-card-title class="border-b-2">
        <span class="text-h5">Atualizar Aluno</span>
      </v-card-title>

      <form class="p-2 px-4 pt-5" @submit="registerStudent">
        <v-text-field
          v-model="studentForm.name"
          variant="underlined"
          label="Nome *"
          required
        />

        <v-text-field
          v-model="studentForm.email"
          variant="underlined"
          label="E-mail *"
          type="email" 
          required
        />

        <v-text-field
          v-model="studentForm.ra"
          variant="underlined"
          label="Registro acadêmico *"
          required
        />

        <v-text-field
          v-model="studentForm.cpf"
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
              Atualizar
            </v-btn>
          </div>
        </div>
      </form>
    </v-card>
  </v-dialog>
</template>

<script lang="ts">
  import { Student } from '@/_types/student'
  import { PropType } from 'vue'
  import { useToast } from 'vue-toastification'

  export default {
    name: 'UpdateStudent',

    props: {
      student: {
        type: Object as PropType<Student>,
        required: true,
      },
    },

    setup() {
      const toast = useToast();

      return { toast }
    },
    
    data() {
      return {
        dialog: false,

        studentForm: {
          name: this.student.name,
          email: this.student.email,
          ra: this.student.ra,
          cpf: this.student.cpf,
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
        e.preventDefault()
        this.loading = true

        // const data = {
        //   name: this.studentForm.name,
        //   email: this.studentForm.email,
        //   ra: this.studentForm.ra,
        //   cpf: this.studentForm.cpf,
        // }

        this.toast.success("Aluno atualizado com sucesso!")

        console.log('register', this.student)
      },

      close () {
        this.dialog = false
      },
    }
  }
</script>