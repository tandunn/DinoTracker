import Service from '@ember/service';
import { inject as service } from '@ember/service';
import loginMutation from "dino-tracker/graphql/mutations/login.graphql";
import createPaleontologistMutation from "dino-tracker/graphql/mutations/createPaleontologist.graphql";
import createResearcherMutation from "dino-tracker/graphql/mutations/createResearcher.graphql";
import getAllPaleontologistsQuery from "dino-tracker/graphql/queries/getAllPaleontologists.graphql";
import getAllResearchersQuery from "dino-tracker/graphql/queries/getAllResearchers.graphql";
import ViewableStaff from 'dino-tracker/viewable-staff';
import EmberArray from '@ember/array';

export default class ApolloRepository extends Service {
  @service apollo: any;

  public async login(variables: { username: string, password: string }): Promise<boolean> {
    return this.apollo.mutate({ mutation: loginMutation, variables }, "login");
  }

  public async createPaleontologist(variables: { name: string, username: string }): Promise<boolean> {
    return this.apollo.mutate({ mutation: createPaleontologistMutation, variables }, "createPaleontologist");
  }

  public async createResearcher(variables: { name: string }): Promise<boolean> {
    return this.apollo.mutate({ mutation: createResearcherMutation, variables }, "createResearcher");
  }

  public async getAllPaleontologists(): Promise<EmberArray<ViewableStaff> > {
    return this.apollo.query({ query: getAllPaleontologistsQuery }, "paleontologists");
  }

  public async getAllResearchers(): Promise<EmberArray<ViewableStaff> > {
    return this.apollo.query({ query: getAllResearchersQuery }, "researchers");
  }
}

// DO NOT DELETE: this is how TypeScript knows how to look up your services.
declare module '@ember/service' {
  interface Registry {
    'apollo-repository': ApolloRepository;
  }
}
