<template>
    <v-card>
        <v-card-title>
            Create Submission
            <v-spacer></v-spacer>
            <v-btn @click="close" icon>
                <v-icon>mdi-close</v-icon>
            </v-btn>
        </v-card-title>

        <v-stepper class="rounded-0" v-model="step">
            <v-stepper-header class="elevation-0">
                <v-stepper-step :complete="step > 1" step="1">Upload Video</v-stepper-step>

                <v-divider></v-divider>

                <v-stepper-step :complete="step > 2" step="2">Select Trick</v-stepper-step>

                <v-divider></v-divider>

                <v-stepper-step :complete="step > 3" step="3">Submission</v-stepper-step>

                <v-divider></v-divider>

                <v-stepper-step step="4">Review</v-stepper-step>
            </v-stepper-header>

            <v-stepper-items>

                <v-stepper-content class="pt-0" step="1">
                    <div>
                        <v-file-input @change="handleFile" accept="video/*"></v-file-input>
                    </div>
                </v-stepper-content>

                <v-stepper-content class="pt-0" step="2">
                    <div>
                        <v-select :items="tricksItems" label="Select Trick" v-model="form.trickId"></v-select>
                        <v-btn @click="step++">Next</v-btn>
                    </div>
                </v-stepper-content>


                <v-stepper-content class="pt-0" step="3">
                    <div>
                        <v-text-field label="Description " v-model="form.description"></v-text-field>
                        <v-btn @click="step++">Next</v-btn>
                    </div>

                </v-stepper-content>

                <v-stepper-content class="pt-0 d-flex justify-center" step="4">
                    <div>
                        <v-btn @click="save">Save</v-btn>
                    </div>
                </v-stepper-content>
            </v-stepper-items>
        </v-stepper>
    </v-card>
</template>

<script>
    import {mapActions, mapMutations, mapGetters} from 'vuex'
    import {close} from "./shared";

    export default {
        name: "submission-steps",
        mixins: [close],
        data: () => ({
            step: 1,
            form: {
                trickId: "",
                video: "",
                description: "",
            }
        }),
        computed: mapGetters('tricks', ['tricksItems']),
        methods: {
            ...mapMutations('video-upload', ['hide']),
            ...mapActions('video-upload', ['startVideoUpload', 'createSubmission']),
            async handleFile(file) {
                if (!file) return;
                const form = new FormData();
                form.append("video", file)
                this.startVideoUpload({form});
                this.step++;
            },
            save() {
                this.createSubmission({form: this.form})
                this.hide();
            },
        }
    }
</script>

<style scoped>

</style>
