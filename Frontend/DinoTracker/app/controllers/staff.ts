import Controller from '@ember/controller';
import { action } from '@ember/object';
import { tracked } from '@glimmer/tracking';
import { inject as service } from "@ember/service";
import ApolloRepository from 'dino-tracker/services/apollo-repository';

export default class Staff extends Controller
{
  @service apolloRepository!: ApolloRepository;

  @tracked isDisplayingErrorMessage = false;
  @tracked isShowingModal = false;
  @tracked isPaleontologist = false;
  @tracked name = '';
  @tracked username = '';

  @action
  toggleCreateUserModal()
  {
    this.isDisplayingErrorMessage = false;
    this.isPaleontologist = false;
    this.name = '';
    this.username = '';
    this.isShowingModal = !this.isShowingModal;
  }

  @action
  toggleIsPaleontologist()
  {
    this.isPaleontologist = !this.isPaleontologist;
  }

  @action
  async attemptCreateUser()
  {
    try
    {
      let response : boolean;
      if (this.isPaleontologist)
      {
        let variables = { name: this.name, username: this.username };
        response = await this.apolloRepository.createPaleontologist(variables);
      }
      else
      {
        let variables = { name: this.name };
        response = await this.apolloRepository.createResearcher(variables);
      }
      if (response == true)
      {
        console.log("User created");
        this.toggleCreateUserModal();
      }
      else
      {
        this.isDisplayingErrorMessage = true;
      }
    }
    catch
    {
      this.isDisplayingErrorMessage = true;
    }
  }
}

// DO NOT DELETE: this is how TypeScript knows how to look up your controllers.
declare module '@ember/controller' {
  interface Registry {
    'staff': Staff;
  }
}
