class PageCall<TMessage, TResponse>
{
    Url: string;
    PageUrl: string;
    PageMember: string;
    Message: TMessage;
}

class Call<TMessage, TResponse>
{
    Url: string;
    Method: string;
    Message: TMessage;
}