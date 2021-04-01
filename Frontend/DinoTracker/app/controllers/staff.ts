import Controller from '@ember/controller';
import { action } from '@ember/object';
import { tracked } from '@glimmer/tracking';
import { inject as service } from "@ember/service";
import ApolloRepository from 'dino-tracker/services/apollo-repository';
import ViewableStaff from 'dino-tracker/viewable-staff';
import EmberArray from '@ember/array';
import Authentication from 'dino-tracker/services/authentication';

export default class Staff extends Controller {
  @service apolloRepository!: ApolloRepository;
  @service authentication!: Authentication;

  @tracked isDisplayingLoginErrorMessage = false;
  @tracked isDisplayingFetchErrorMessage = false;
  @tracked isShowingModal = false;
  @tracked isPaleontologist = false;
  @tracked hasCreateAccess = false;
  @tracked name = '';
  @tracked username = '';
  @tracked paleontologists!: EmberArray<ViewableStaff>;
  @tracked researchers!: EmberArray<ViewableStaff>;

  @action
  toggleCreateUserModal() {
    this.isDisplayingLoginErrorMessage = false;
    this.isPaleontologist = false;
    this.name = '';
    this.username = '';
    this.isShowingModal = !this.isShowingModal;
  }

  @action
  toggleIsPaleontologist() {
    this.isPaleontologist = !this.isPaleontologist;
  }

  @action
  async attemptCreateUser() {
    try {
      let response: boolean;
      if (this.isPaleontologist) {
        let variables = { name: this.name, username: this.username };
        response = await this.apolloRepository.createPaleontologist(variables);
      }
      else {
        let variables = { name: this.name };
        response = await this.apolloRepository.createResearcher(variables);
      }
      if (response == true) {
        this.toggleCreateUserModal();
        this.fetchStaff();
      }
      else {
        this.isDisplayingLoginErrorMessage = true;
      }
    }
    catch
    {
      this.isDisplayingLoginErrorMessage = true;
    }
  }

  @action
  async fetchStaff() {
    try {
      this.paleontologists = await this.apolloRepository.getAllPaleontologists();
      this.researchers = await this.apolloRepository.getAllResearchers();
    }
    catch
    {
      this.isDisplayingFetchErrorMessage = true;
    }
  }

  @action
  checkCreateAccess()
  {
    if (this.authentication.isLoggedIn && this.authentication.username == "user1") // Head Paleontologist
    {
      this.hasCreateAccess = true;
    }
    else
    {
      this.hasCreateAccess = false;
    }
  }
}

// DO NOT DELETE: this is how TypeScript knows how to look up your controllers.
declare module '@ember/controller' {
  interface Registry {
    'staff': Staff;
  }
}
