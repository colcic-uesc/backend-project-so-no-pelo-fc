export const apiCall = async <T>(
  url: string, 
  options: RequestInit = {}
): Promise<T> => {
  const token = localStorage.getItem('token')

  const headers: HeadersInit = {
    'Content-Type': 'application/json',
    ...(token && { Authorization: `Bearer: ${token}` }),
    ...options.headers
  }

  const res = await fetch(url, {
    ...options,
    headers
  })

  if (!res.ok) 
    throw new Error(`API call failed with status: ${res.status}`);
  
  return (await res.json()) as T
}