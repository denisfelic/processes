import {
  QueryClient,
  QueryClientProvider,
  useQuery,
} from "@tanstack/react-query";

function App() {
  const queryClient = new QueryClient();

  return (
    <QueryClientProvider client={queryClient}>
      <ProcessListScreen />
    </QueryClientProvider>
  );
}

export default App;

const API_BASE_URL = "http://localhost:5226/api";

interface IProcess {
  id: number;
  name: string;
  status: boolean;
}
function useProcessService() {
  const ROUTES = {
    GET_PROCESSES: "/processes",
  };
  const getProcesses = async (): Promise<IProcess[]> => {
    const response = await fetch(API_BASE_URL + ROUTES.GET_PROCESSES);
    return response.json();
  };

  return {
    getProcesses,
  };
}

function ProcessListScreen() {
  const { getProcesses } = useProcessService();
  const { data, isPending, error } = useQuery({
    queryKey: [""],
    queryFn: () => getProcesses(),
  });

  const getProcessingMsg = () => {
    if (isPending)
      return (
        <>
          <svg
            xmlns="http://www.w3.org/2000/svg"
            fill="none"
            viewBox="0 0 24 24"
            strokeWidth={1.5}
            stroke="currentColor"
            className="size-6 animate-spin"
          >
            <path
              strokeLinecap="round"
              strokeLinejoin="round"
              d="M16.023 9.348h4.992v-.001M2.985 19.644v-4.992m0 0h4.992m-4.993 0 3.181 3.183a8.25 8.25 0 0 0 13.803-3.7M4.031 9.865a8.25 8.25 0 0 1 13.803-3.7l3.181 3.182m0-4.991v4.99"
            />
          </svg>
        </>
      );

    if (error) return "error";
  };

  const processingMsg = getProcessingMsg();

  console.log("data", { data });

  return (
    <div>
      <h1>Process list</h1>
      {processingMsg ? (
        processingMsg
      ) : (
        <table>
          <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Status</th>
          </tr>
          {data?.map((process, i) => (
            <tr key={i}>
              <td>{process.id}</td>
              <td>{process.name}</td>
              <td>{process.status ? "Active" : "Inactive"}</td>
            </tr>
          ))}
        </table>
      )}
    </div>
  );
}
