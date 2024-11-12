<template>
  <v-dialog
    v-model="dialog"
    max-width="500px"
  >
    <template v-slot:activator="{ props }">
      <v-btn 
        density="compact" 
        rounded
        icon="mdi-delete-outline" 
        color="error"
        v-bind="props"
      />
    </template>

    <v-card>
      <v-card-title class="border-b-2">
        <span class="text-h5">Excluir Aluno</span>
      </v-card-title>

      <div class="p-2 px-4 pt-5">
        <div>
          <p>
            Tem certeza que deseja excluir o aluno
            <span class="font-medium">{{ student.name }}</span> ?
          </p>
        </div>

        <div class="flex items-center justify-end space-x-2 mt-4">
          <div>
            <v-btn
              class="text-subtitle-1 flex-grow-1 w-full sm:w-auto justify-center rounded-md bg-primary font-medium shadow-sm hover:opacity-80"
              variant="flat"
              color=""
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
              color="error"
              type="submit"
              @click="deleteStudent"
            >
              Confirmar
            </v-btn>
          </div>
        </div>
      </div>
    </v-card>
  </v-dialog>
</template>

<script lang="ts">
  import { Student } from '@/_types/student'
  import { PropType } from 'vue'
  import { useToast } from 'vue-toastification'

  export default {
    name: 'DeleteStudent',

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

        loading: false,
      }
  },

    watch: {
      dialog (val) {
        val || this.close()
      },
    },

    methods: {
      deleteStudent (e: MouseEvent) {
        e.preventDefault()
        this.loading = true

        // const data = {
        //   name: this.studentForm.name,
        //   email: this.studentForm.email,
        //   ra: this.studentForm.ra,
        //   cpf: this.studentForm.cpf,
        // }

        this.toast.success("Aluno excluído com sucesso!")

        console.log('register', this.student)
      },

      close () {
        this.dialog = false
        this.loading = false
      },
    }
  }
</script>