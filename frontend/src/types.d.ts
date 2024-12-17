interface Student {
  id: number;
  registration: string;
  name: string;
  email: string;
  course: string;
  bio: string;
  user: {
    username: string;
    rules: string;
  };
}
