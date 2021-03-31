import Service from '@ember/service';
import { inject as service } from '@ember/service';
import loginMutation from "dino-tracker/graphql/mutations/login.graphql";
import createUserMutation from "dino-tracker/graphql/mutations/createUser.graphql";


export default class ApolloRepository extends Service.extend({
  // anything which *must* be merged to prototype here
}) {
  @service apollo: any;

  public async login(variables: { username: string, password: string }): Promise<boolean>
  {
    try
    {
      let response = await this.apollo.mutate({ mutation: loginMutation, variables }, "login");
      return response;
    }
    catch
    {
      return false;
    }
  }

  public async createUser(variables: { name: string, username: string}): Promise<boolean>
  {
    try
    {
      let response = await this.apollo.mutate({ mutation: createUserMutation, variables }, "createUser");
      return response;
    }
    catch
    {
      return false;
    }
  }
}

// DO NOT DELETE: this is how TypeScript knows how to look up your services.
declare module '@ember/service' {
  interface Registry {
    'apollo-repository': ApolloRepository;
  }
}
