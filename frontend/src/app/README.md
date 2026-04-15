# Frontend Folder Structure

This app uses a simple Angular structure that is easy to explain and reuse in other projects.

## Folders

- `core/` - app-wide code used once in the whole application.
- `shared/` - reusable pieces used in many places.
- `features/` - one folder per business feature or page group.
- `layouts/` - page shells like main layout and auth layout.
- `environments/` - API URLs and environment settings.

## Example usage

- Put auth pages in `features/auth/pages`.
- Put API calls for auth in `features/auth/services`.
- Put reusable UI components in `shared/components`.
- Put interceptors, guards, and singleton services in `core`.
